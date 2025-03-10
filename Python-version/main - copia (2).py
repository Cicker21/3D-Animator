from vpython import *

# Crear la escena
scene = canvas(title="Cubo girando con control de velocidad")

# Crear el cubo
cubo = box(pos=vector(0, 0, 0), size=vector(1, 1, 1), color=color.red)

# Velocidades iniciales de rotación
wx = 0.2  # Velocidad en X
wy = -0.3  # Velocidad en Y
dt = 0.1  # Paso de tiempo
t = 0  # Tiempo inicial

# Crear sliders para controlar la velocidad
def update_wx():
    global wx
    wx = slider_x.value

def update_wy():
    global wy
    wy = slider_y.value

slider_x = slider(min=-5, max=5, value=wx, length=300, bind=update_wx, text="Velocidad X")
slider_y = slider(min=-5, max=5, value=wy, length=300, bind=update_wy, text="Velocidad Y")

# Crear texto para mostrar valores actuales
info = wtext(text=f"t = {t:.1f} s | RotX = {wx*t:.2f} rad | RotY = {wy*t:.2f} rad\n")

# Crear texto para mostrar las coordenadas de los vértices
vertices_info = wtext(text="Coordenadas del cubo:\n")

# Función para calcular las coordenadas de los vértices
def calcular_vertices(cubo):
    half_size = cubo.size / 2
    # Vértices sin rotar
    vertices = [
        cubo.pos + vector(x * half_size.x, y * half_size.y, z * half_size.z)
        for x in [-1, 1] for y in [-1, 1] for z in [-1, 1]
    ]
    
    # Aplicar rotación a los vértices
    rotated_vertices = []
    for v in vertices:
        # Rotar el vector con respecto a las rotaciones acumuladas
        rotated_v = v - cubo.pos  # Restamos la posición del cubo
        rotated_v = rotated_v.rotate(angle=wx * dt, axis=vector(1, 0, 0))  # Rotación alrededor del eje X
        rotated_v = rotated_v.rotate(angle=wy * dt, axis=vector(0, 1, 0))  # Rotación alrededor del eje Y
        rotated_v = rotated_v + cubo.pos  # Sumamos la posición original del cubo
        rotated_vertices.append(rotated_v)
    
    return rotated_vertices

# Animación en tiempo real
while True:
    rate(20)  # Controla la velocidad de la animación (20 FPS)

    # Rotar el cubo con los valores actualizados de los sliders
    cubo.rotate(angle=wx * dt, axis=vector(1, 0, 0))  # Rotación en X
    cubo.rotate(angle=wy * dt, axis=vector(0, 1, 0))  # Rotación en Y

    # Actualizar tiempo
    t += dt

    # Obtener las coordenadas de los vértices
    vertices = calcular_vertices(cubo)

    # Crear el texto con las coordenadas de los vértices
    vertices_text = "Coordenadas del cubo:\n"
    for v in vertices:
        vertices_text += f"({v.x:.2f}, {v.y:.2f}, {v.z:.2f})\n"

    # Actualizar la información en pantalla
    info.text = f"t = {t:.1f} s | RotX = {wx*t:.2f} rad | RotY = {wy*t:.2f} rad\n"
    vertices_info.text = vertices_text
