import bpy

allObjects = list(bpy.data.objects)

for element in allObjects:
    if (str(element.get('objecttype')) == 'None') and (element.type == 'MESH') and not (element.name == 'options'):
        # We are changing the defualt to imported since that most probably will end being the standard form for everything
        # We will still need to see how to interact the options with everything at this stage of the game it will be a multiple of the local number
        element["objecttype"] = "imported"
        element["material"] = "pla"
        element["priority"] = 100.0
        # here we add the options X Y Z RX RY RZ SX SY SZ
        # these properties are the ones that will be copied into the 3dr file
        # default the properties take after their current position but can be changed into options and be copied as such
        element["X"] = str(element.location.x)
        element["Y"] = str(element.location.y)
        element["Z"] = str(element.location.z)
        element["RX"] = str(element.rotation_euler.x * 57.2957795131)
        element["RY"] = str(element.rotation_euler.y * 57.2957795131)
        element["RZ"] = str(element.rotation_euler.z * 57.2957795131)
        element["SX"] = str(str(element.scale.x) + '/' + str(element.scale.x))
        element["SY"] = str(str(element.scale.y) + '/' + str(element.scale.y))
        element["SZ"] = str(str(element.scale.z) + '/' + str(element.scale.z))

preempty = None
# create a empty object options to allow for storage of options in it
if bpy.data.objects.get("Empty") is not None:
    preempty = bpy.data.objects['Empty']
    preempty.name = 'options1'
if bpy.data.objects.get("options") is None:
    bpy.ops.object.add(radius = 1.0, type = 'EMPTY')
    empty = bpy.data.objects['Empty']
    empty.name = 'options'
# rename the previous existing empty back
if preempty is not None:
    preempty.name = 'Empty'
