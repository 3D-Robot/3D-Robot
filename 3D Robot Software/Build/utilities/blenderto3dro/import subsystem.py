# we let the user choose a file as a subsystem
# We import the file and parent all the parts under a objected named by the file name
# We add all the options with the added file name to the options
# We rename all options to match the new options
import bpy

allObjects = list(bpy.data.objects)

bpy.ops.wm.path_open(filepath = 'C:/Users/yfukesman/Downloads/projects/software and other files/other prints/house table/drawers/rail/rail.blend')

bpy.ops.object.add(radius = 1.0, type = 'EMPTY')
empty = bpy.data.objects['Empty']
empty.name = bpy.data.filepath

bpy.ops.object.select_all(action = 'SELECT')

bpy.ops.object.parent_set(keep_transform = True)

# copy all of the old options into the new options with the prefix of the filename
for K in bpy.data.objects['options'].keys():
    if K not in '_RNA_UI':
        
