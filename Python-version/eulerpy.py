from vpython import *
import numpy as np

# Escena 3D
scene = canvas(title="Cubo girando con rotaciones Euler ZYX", width=800, height=600)
scene.background = color.white

# Crear cubo
cubo = box(pos=vector(0, 0, 0), size=vector(1, 1, 1), color=color.red)

# Ángulos iniciales
phi = 0     # (Z)
theta = 0   #  (Y)
psi = 0     #  (X)

# Incrementos por frame
delta_phi = np.pi / 180     # 1° por frame
delta_theta = np.pi / 360   # 0.5° por frame
delta_psi = np.pi / 720     # 0.25° por frame

# Bucle de animación
while True:
    rate(30)

    # Calcular incremento de matriz de rotación, en cada frame lo aumentamos para que el cubo siga rotand0
    phi += delta_phi
    theta += delta_theta
    psi += delta_psi

    # Matrices individuales
    c1, s1 = np.cos(phi), np.sin(phi)
    Rz = np.array([[c1, -s1, 0], [s1, c1, 0], [0, 0, 1]]) #eje z 

    c2, s2 = np.cos(theta), np.sin(theta)
    Ry = np.array([[c2, 0, s2], [0, 1, 0], [-s2, 0, c2]]) #eje y 

    c3, s3 = np.cos(psi), np.sin(psi)
    Rx = np.array([[1, 0, 0], [0, c3, -s3], [0, s3, c3]]) #eje x

    # combinamos las matrices en orden zyx que es el orden de euler
    R = Rx @ Ry @ Rz

    # Convertir a vectores para VPython
    new_axis = vector(*R[:, 0])   # dirección local x
    new_up = vector(*R[:, 1])     # dirección local y

    # Aplicar orientación al cubo
    cubo.axis = new_axis
    cubo.up = new_up

    # (Opcional) Mostrar en consola
    print(f"Yaw: {phi*180/np.pi:.1f}°, Pitch: {theta*180/np.pi:.1f}°, Roll: {psi*180/np.pi:.1f}°")