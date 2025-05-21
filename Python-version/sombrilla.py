import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation
from mpl_toolkits.mplot3d import Axes3D

def parse_sombrilla_data(file_content):
    """Parse the sombrilla data from the CSV file content"""
    frames = []
    
    # Split into frames (rows in CSV)
    frame_strings = file_content.strip().split('\n')
    
    for frame_str in frame_strings:
        frame = []
        # Split into segments separated by |
        segments = frame_str.split('|')
        
        for seg in segments:
            # Split into points separated by =
            points = seg.split('=')
            polygon = []
            
            for pt in points:
                if pt:
                    x, y, z = map(float, pt.split(','))
                    polygon.append([x, y, z])
            
            if polygon:  # Only add non-empty polygons
                frame.append(np.array(polygon))
        
        frames.append(frame)
    
    return frames

# Read the file content (you would load this from your actual file)
with open('sombrillaa.csv', 'r') as f:
    file_content = f.read()

# Parse the data
frames = parse_sombrilla_data(file_content)

# Create figure
fig = plt.figure(figsize=(10, 8))
ax = fig.add_subplot(111, projection='3d')

# Remove axes and background for cleaner look
ax.set_axis_off()
ax.grid(False)
ax.set_facecolor('none')
fig.patch.set_facecolor('none')

# Set initial viewing angle
ax.view_init(elev=30, azim=45)

# Create empty plot elements
polygons = []
for _ in frames[0]:
    poly, = ax.plot([], [], [], color='skyblue', alpha=0.8, linewidth=1)
    polygons.append(poly)

def init():
    """Initialize the animation"""
    for poly in polygons:
        poly.set_data([], [])
        poly.set_3d_properties([])
    return polygons

def update(frame_num):
    """Update the plot for each frame"""
    for poly, data in zip(polygons, frames[frame_num]):
        x = data[:, 0]
        y = data[:, 1]
        z = data[:, 2]
        
        # Close the polygon
        x = np.append(x, x[0])
        y = np.append(y, y[0])
        z = np.append(z, z[0])
        
        poly.set_data(x, y)
        poly.set_3d_properties(z)
    
    # Adjust view to follow the movement
    ax.set_xlim(-2, 2)
    ax.set_ylim(-2, 2)
    ax.set_zlim(9, 12)
    
    return polygons

# Create animation
ani = FuncAnimation(
    fig, update, frames=len(frames),
    init_func=init, blit=False, interval=50
)

plt.tight_layout()
plt.show()

# To save the animation (uncomment if needed)
# ani.save('sombrilla_animation.mp4', writer='ffmpeg', fps=20, dpi=300)