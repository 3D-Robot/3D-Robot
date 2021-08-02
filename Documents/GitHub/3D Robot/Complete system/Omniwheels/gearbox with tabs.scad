
translate([0,0,55/2]){rotate(a = [-90,0,0]){import("planetary gearbox 2mm modulus.stl");}}

high = 5;
boltdia = 3;
surrond = 3.5;
module tabs(){
    difference(){
        translate([-(boltdia+surrond*2)/2,-(boltdia+surrond*2)/2,0]){cube([boltdia+surrond*2, boltdia+surrond*2, high]);}
        translate([0,0,-.1]){cylinder(r = boltdia/2, h = high + 1, $fn = 20);}
    }
}

translate([55/2+(boltdia+surrond*2)/2,+(boltdia+surrond*2)/2,0]){tabs();}
translate([-55/2-(boltdia+surrond*2)/2,+(boltdia+surrond*2)/2,0]){tabs();}