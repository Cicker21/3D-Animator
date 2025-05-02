from vpython import *
import os

# Configuración de la escena
scene = canvas(title="Animación de Cubo Completo", width=800, height=600)
scene.background = color.white
scene.autoscale = True

# Variables globales
archivo_csv = 'cubos.csv'
caras_por_frame = []  # Almacenará las 6 caras (cada una con 4 vértices) por frame
current_frame = 0
playing = False
caras_visuales = []

def mostrar_error(mensaje):
    scene.title = mensaje
    print(mensaje)
    while True:
        rate(30)

def parse_csv_line(line):
    """Procesa una línea del CSV y extrae las 6 caras del cubo (4 vértices cada una)"""
    caras = []
    # Dividir por "|" para separar las caras
    partes_caras = line.strip().split('|')
    
    for cara_str in partes_caras:
        if not cara_str.strip():
            continue
        
        # Extraer los 4 vértices de la cara
        vertices_str = cara_str.strip().split('=')
        vertices = []
        
        for v_str in vertices_str:
            if not v_str.strip():
                continue
            try:
                coords = list(map(float, v_str.strip().split(',')))
                if len(coords) == 3:
                    vertices.append(vector(*coords))
            except:
                continue
        
        # Cada cara debe tener exactamente 4 vértices
        if len(vertices) == 4:
            caras.append(vertices)
    
    # Debe haber exactamente 6 caras
    return caras if len(caras) == 6 else None

def cargar_animacion():
    global caras_por_frame
    
    try:
        if not os.path.exists(archivo_csv):
            mostrar_error(f"❌ Archivo no encontrado: {archivo_csv}")
        
        with open(archivo_csv, 'r') as file:
            for line in file:
                if line.strip():
                    caras = parse_csv_line(line)
                    if caras:
                        caras_por_frame.append(caras)
        
        if not caras_por_frame:
            mostrar_error("❌ No se encontraron frames válidos.")
        else:
            print(f"✅ {len(caras_por_frame)} frames cargados correctamente.")
            mostrar_frame(0)
            
    except Exception as e:
        mostrar_error(f"❌ Error: {str(e)}")

def crear_caras_visuales(caras):
    """Crea las 6 caras del cubo como mallas independientes"""
    objetos = []
    colores = [color.red, color.green, color.blue, 
               color.yellow, color.orange, color.magenta]
    
    for i, cara in enumerate(caras):
        # Crear la cara como un cuadrilátero
        f = quad(
            vs = [
                vertex(pos=cara[0], color=colores[i]),
                vertex(pos=cara[1], color=colores[i]),
                vertex(pos=cara[2], color=colores[i]),
                vertex(pos=cara[3], color=colores[i])
            ],
            opacity=0.7
        )
        objetos.append(f)
        
        # Opcional: dibujar el borde de la cara
        for j in range(4):
            objetos.append(
                curve(
                    pos=[cara[j], cara[(j+1)%4]],
                    radius=0.03,
                    color=color.black
                )
            )
    
    return objetos

def mostrar_frame(n):
    global current_frame, caras_visuales
    
    current_frame = n % len(caras_por_frame)
    caras = caras_por_frame[current_frame]
    
    # Eliminar caras anteriores
    for obj in caras_visuales:
        obj.visible = False
    caras_visuales.clear()
    
    # Crear nuevas caras
    caras_visuales = crear_caras_visuales(caras)
    
    scene.title = f"Frame {current_frame + 1}/{len(caras_por_frame)}"

def toggle_play():
    global playing
    playing = not playing

def animar():
    while True:
        if playing and caras_por_frame:
            mostrar_frame(current_frame + 1)
        rate(30)  # 30 FPS

# Inicialización
cargar_animacion()

# Controles
scene.bind('click', lambda ev: toggle_play())
print("🖱️ Haz clic en la ventana para Play/Pause")

# Bucle principal
animar()