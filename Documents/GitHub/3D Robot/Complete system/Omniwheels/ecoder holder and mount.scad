//the encoder is based off of the KY-040 Arduino Rotary Encoder

$fn = 20;
//encoder size 
encoderx = 5;
encodery = 2;
encoderz = 10;
//thickness of the whole assembly
thickness = 5;
//height of center of shaft from floor
encodershaftheight = 42;
//height of encoder after the shaft
heightaboveshaft = 5;
//surronding wall of encoder
wallsurrond = 5;
//hole for wires to exit from back
wireexitholedia = 5;
//mounting bolts
mountboltdia = 3;
mountthick = 3;
mountboltsurrond = 2;

difference(){
    union(){
        //mount
        translate([-((encoderx+thickness*2)+(mountboltdia+mountboltsurrond*2)*2)/2,-(0)/2,0]){cube([(encoderx+thickness*2)+(mountboltdia+mountboltsurrond*2)*2, thickness,mountthick]);}
        //top
        translate([-(encoderx+thickness*2)/2,(0)/2,mountthick]){cube([encoderx+thickness*2,thickness,encodershaftheight++heightaboveshaft+thickness]);}
    }
    
    union(){
        //mounting
        translate([((encoderx+thickness*2)/2+((mountboltdia+mountboltsurrond*2))/2),thickness/2,-1]){cylinder(r = mountboltdia/2, h = mountthick+2);}
        translate([-((encoderx+thickness*2)/2+((mountboltdia+mountboltsurrond*2))/2),thickness/2,-1]){cylinder(r = mountboltdia/2, h = mountthick+2);}
        //wires exit
        translate([0,0,(encodershaftheight+heightaboveshaft-encoderz)+wireexitholedia/2]){rotate(a = [270,0,0]){cylinder(r = wireexitholedia/2, h = thickness + 1);}}
        //encoder
        translate([-(encoderx)/2,-.01,encodershaftheight+heightaboveshaft-encoderz]){cube([encoderx, encodery, encoderz]);}
    }
}