import numpy as np
import socket
import time
import json

# Parámetros del péndulo doble
m1 = 1.0
m2 = 2.0
L1 = 1.0
L2 = 2.0
g = 9.8

# Condiciones iniciales
theta1 = np.pi/2
theta2 = np.pi
omega1 = 0
omega2 = 0
y0 = np.array([theta1, omega1, theta2, omega2])

# Tiempo de la simulación y paso de tiempo
t = np.linspace(0, 30, 1500)
dt = t[1] - t[0]

# Función para la derivada del sistema
def dy_dt(y, t, m1, m2, L1, L2, g):
    theta1, omega1, theta2, omega2 = y
    dtheta1_dt = omega1
    domega1_dt = (m2*g*np.sin(theta2)*np.cos(theta1-theta2) - m2*np.sin(theta1-theta2)\
                  *(L1*omega1*2*np.cos(theta1-theta2) + L2*omega2*2) - (m1+m2)*g*np.sin(theta1)) / \
                 (L1*(m1+m2*np.sin(theta1-theta2)**2))
    dtheta2_dt = omega2
    domega2_dt = ((m1+m2)*(L1*omega1*2*np.sin(theta1-theta2) - g*np.sin(theta2) + g*np.sin(theta1)*np.cos(theta1-theta2)) + \
                 m2*L2*omega2**2*np.sin(theta1-theta2)*np.cos(theta1-theta2)) / \
                 (L2*(m1+m2*np.sin(theta1-theta2)**2))
    return np.array([dtheta1_dt, domega1_dt, dtheta2_dt, domega2_dt])


# Configuración del socket
class ServidorPython:
    def __init__(self, host='localhost', port=12345):
        self.host = host
        self.port = port
        self.socket = None
        self.server_socket = None  # Socket para modo servidor

        self.theta1 = theta1
        self.omega1 = omega1
        self.theta2 = theta2
        self.omega2 = omega2
        self.frame = 0

    def iniciar_servidor(self):
        """Inicia el servidor socket para esperar conexiones"""
        self.server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.server_socket.bind((self.host, self.port))
        self.server_socket.listen(1)
        print(f"Servidor Python iniciado en {self.host}:{self.port}. Esperando conexión...")
        
        # Aceptar conexión entrante
        self.socket, addr = self.server_socket.accept()
        print(f"Conexión establecida desde {addr}")

    def enviar_datos(self):
        """Envía los datos actuales a través del socket"""
        data = f"{self.frame},{self.theta1},{self.omega1},{self.theta2},{self.omega2}"
        
        json_data = json.dumps(data)
        self.socket.sendall(data.encode('utf-8'))
        print(f"Enviado: {json_data}")

    def cerrar(self):
        """Cierra la conexión"""
        if self.socket:
            self.socket.close()
        if self.server_socket:
            self.server_socket.close()
        print("Conexión cerrada")

# Solución del sistema de ecuaciones diferenciales
def pendulo_doble(servidor):

    y = np.zeros((len(t), 4))
    y[0] = y0
    for i in range(len(t)-1):
        y[i+1] = y[i] + dy_dt(y[i], t[i], m1, m2, L1, L2, g)*dt
        servidor.theta1 = y[i+1][0]
        servidor.omega1 = y[i+1][1]
        servidor.theta2 = y[i+1][2]
        servidor.omega2 = y[i+1][3]
        servidor.frame = i+1
        servidor.enviar_datos()
        time.sleep(0.05)  # Espera 0.5 segundos entre cada paso
        print(f"Paso {i+1}/{len(t)-1}: theta1={y[i+1][0]:.4f}, omega1={y[i+1][1]:.4f}, theta2={y[i+1][2]:.4f}, omega2={y[i+1][3]:.4f}")

if __name__ == "__main__":
    servidor = ServidorPython()
    try:
        servidor.iniciar_servidor()  # Ahora Python actúa como servidor
        pendulo_doble(servidor)
    except KeyboardInterrupt:
        print("\nSimulación interrumpida por el usuario")
    finally:
        servidor.cerrar()