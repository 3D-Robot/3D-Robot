
$fn = 100;
alsquareside = 26;
motorshaftdia = 8;
distcentertocenterextrusions = 36;
extrusionsurrond = 5;
surrondheight = 20;


module gimbalholder(){
    difference(){
        union(){
            translate([-(distcentertocenterextrusions + alsquareside + extrusionsurrond * 2)/2,-(alsquareside + extrusionsurrond * 2)/2,0]){cube([distcentertocenterextrusions + alsquareside + extrusionsurrond * 2, alsquareside + extrusionsurrond * 2, extrusionsurrond + surrondheight]);}
        }
        
        union(){
            translate([0,0,-.1]){cylinder(r = motorshaftdia/2, h = extrusionsurrond + surrondheight + 1);}
            translate([distcentertocenterextrusions/2-alsquareside/2,-alsquareside/2,extrusionsurrond]){cube([alsquareside, alsquareside,extrusionsurrond+surrondheight + 1]);}
            translate([-distcentertocenterextrusions/2-alsquareside/2,-alsquareside/2,extrusionsurrond]){cube([alsquareside, alsquareside,extrusionsurrond+surrondheight + 1]);}
        }
       
}}
gimbalholder();