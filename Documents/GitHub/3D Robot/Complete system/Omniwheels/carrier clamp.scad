$fn = 100;
thickness = 3;
//thickness of the gearbox and the carriers
boxthickness = 10+5*2+.3;
//output boltdia
boltdia = 8;
//input motor shaftdia
shaftdia = 5;
//small bump to keep grip
bump = .5;
//legnth of the gearbox
gearboxside = 45.4;



difference(){
    union(){
        translate([gearboxside/2,-(boxthickness+thickness*2)/2,-(boltdia+thickness*2)/2]){cube([thickness, boxthickness+thickness*2,boltdia+thickness*2]);}
        translate([-boltdia/2-thickness,-(boxthickness+thickness*2)/2,-(boltdia+thickness*2)/2]){cube([gearboxside/2+boltdia/2+thickness,thickness,boltdia+thickness*2]);}
        translate([-boltdia/2-thickness,(boxthickness+thickness*2)/2-thickness,-(boltdia+thickness*2)/2]){cube([gearboxside/2+boltdia/2+thickness,thickness,boltdia+thickness*2]);}
    }
    
    union(){
        translate(){rotate(a= [90,0,0]){cylinder(r = boltdia/2, h = (boxthickness+thickness*2)/2+1);}}
        translate([-(boltdia+thickness+1),-((boxthickness+thickness*2)/2+1),-(boltdia-bump*2)/2]){cube([boltdia+thickness+1,(boxthickness+thickness*2)/2+1,boltdia-bump*2]);}
       translate(){rotate(a= [270,0,0]){cylinder(r = shaftdia/2, h = (boxthickness+thickness*2)/2+1);}}
        translate([-(boltdia+thickness+1),0,-(shaftdia-bump*2)/2]){cube([boltdia+thickness+1,(boxthickness+thickness*2)/2+1,shaftdia-bump*2]);}
    }
}