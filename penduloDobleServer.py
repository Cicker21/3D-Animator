import numpy as np
import socket
import time
import threading

# Parámetros del péndulo doble
m1 = 1.0
m2 = 2.0
L1 = 1.0
L2 = 2.0
g = 9.8

# Estado global del péndulo y control
global_state = {
    'frame': 0,
    'theta1': np.pi/2,
    'omega1': 0,
    'theta2': np.pi,
    'omega2': 0,
    'active': False
}

state_lock = threading.Lock()
clients_lock = threading.Lock()
active_clients = 0
dt = 0.02

# Función dy_dt se mantiene igual
def dy_dt(y, t, m1, m2, L1, L2, g):
    theta1, omega1, theta2, omega2 = y
    dtheta1_dt = omega1
    domega1_dt = (m2*g*np.sin(theta2)*np.cos(theta1-theta2) - m2*np.sin(theta1-theta2)\
                  *(L1*omega1**2*np.cos(theta1-theta2) + L2*omega2**2) - (m1+m2)*g*np.sin(theta1)) / \
                 (L1*(m1+m2*np.sin(theta1-theta2)**2))
    dtheta2_dt = omega2
    domega2_dt = ((m1+m2)*(L1*omega1**2*np.sin(theta1-theta2) - g*np.sin(theta2) + g*np.sin(theta1)*np.cos(theta1-theta2)) + \
                 m2*L2*omega2**2*np.sin(theta1-theta2)*np.cos(theta1-theta2)) / \
                 (L2*(m1+m2*np.sin(theta1-theta2)**2))
    return np.array([dtheta1_dt, domega1_dt, dtheta2_dt, domega2_dt])

class ClientHandler(threading.Thread):
    def __init__(self, connection, address, server):
        threading.Thread.__init__(self)
        self.connection = connection
        self.address = address
        self.server = server
        self.running = True
        
    def run(self):
        global active_clients
        
        with clients_lock:
            active_clients += 1
            if active_clients == 1:
                with state_lock:
                    global_state['active'] = True
        
        print(f"Conexión establecida desde {self.address}")
        try:
            while self.running and self.server.running:
                with state_lock:
                    if not global_state['active']:
                        break
                    data = f"{global_state['frame']},{global_state['theta1']},{global_state['omega1']},{global_state['theta2']},{global_state['omega2']}"
                
                try:
                    self.connection.sendall(data.encode('utf-8'))
                    time.sleep(0.05)
                except (ConnectionError, OSError):
                    # Captura todos los errores de conexión
                    break
        finally:
            with clients_lock:
                active_clients -= 1
                if active_clients == 0:
                    with state_lock:
                        global_state['active'] = False
            
            try:
                self.connection.close()
            except:
                pass
            
            print(f"Cliente {self.address} desconectado")
class ServidorPython:
    def __init__(self, host='localhost', port=12345):
        self.host = host
        self.port = port
        self.server_socket = None
        self.clients = []
        self.simulation_thread = None
        self.running = False
        
    def iniciar_servidor(self):
        self.server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
        self.server_socket.bind((self.host, self.port))
        self.server_socket.listen(5)
        print(f"Servidor escuchando en {self.host}:{self.port}")
        
        self.running = True
        self.simulation_thread = threading.Thread(target=self.actualizar_pendulo)
        self.simulation_thread.start()
        
        while self.running:
            try:
                connection, address = self.server_socket.accept()
                if not self.running:
                    break
                    
                client_handler = ClientHandler(connection, address, self)
                client_handler.start()
                self.clients = [c for c in self.clients if c.is_alive()]
                self.clients.append(client_handler)
            except OSError:
                break
    
    def actualizar_pendulo(self):
        y = np.array([global_state['theta1'], global_state['omega1'], 
                      global_state['theta2'], global_state['omega2']])
        frame = 0
        
        while self.running:
            with state_lock:
                if not global_state['active']:
                    time.sleep(0.1)
                    continue
                
                y = y + dy_dt(y, frame*dt, m1, m2, L1, L2, g)*dt
                
                global_state.update({
                    'frame': frame,
                    'theta1': y[0],
                    'omega1': y[1],
                    'theta2': y[2],
                    'omega2': y[3]
                })
            
            print(f"Paso {frame}: theta1={y[0]:.4f}, omega1={y[1]:.4f}, theta2={y[2]:.4f}, omega2={y[3]:.4f}")
            frame += 1
            time.sleep(0.05)
    
    def cerrar(self):
        self.running = False
        
        # Cerrar socket para desbloquear el accept()
        if self.server_socket:
            try:
                self.server_socket.shutdown(socket.SHUT_RDWR)
                self.server_socket.close()
            except OSError:
                pass
        
        # Cerrar clientes
        for client in self.clients:
            client.running = False
            if client.is_alive():
                client.join()
        
        # Detener simulación
        if self.simulation_thread and self.simulation_thread.is_alive():
            self.simulation_thread.join()
        
        print("Servidor detenido correctamente")

if __name__ == "__main__":
    servidor = ServidorPython()
    try:
        servidor.iniciar_servidor()
    except KeyboardInterrupt:
        print("\nServidor interrumpido por el usuario")
    finally:
        servidor.cerrar()