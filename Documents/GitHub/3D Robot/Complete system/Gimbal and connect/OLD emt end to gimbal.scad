
//We are changing the emts for square tubes!
hubboltsdia = 3;
numhubbolts = 4;
hubboltsplacementradius = 25.4;
hubsurrond = 5;
hubdia = (hubboltsplacementradius + hubsurrond)*2;
hubthickness = 6;
gearshaftdia = 8;
//emt variables
//from center of emts
distemts = 36;
Alsquareside = 26;
wallthickness = 5;
wallthicknesslegnth = 10;
legnth = 20;
//the dia of the holding bolt (into the emt)
emtboltdia = 5;
holediaupper = 8;
holediaupperlegnth = 3;

module holdingscrews()
{
            //?how many at which angles
translate([(distemts+Alsquareside+wallthickness*2)/2+(distemts/2),wallthicknesslegnth+legnth/2,Alsquareside+wallthickness*2+.01]){rotate(a = [180,0,0]){cylinder(r = emtboltdia/2, h = wallthickness+5, $fn = 100);
cylinder(r1 = holediaupper/2, r2 = emtboltdia/2, h = holediaupperlegnth,$fn = 100);}}

translate([(distemts+Alsquareside+wallthickness*2)/2-(distemts/2),wallthicknesslegnth+legnth/2,Alsquareside+wallthickness*2+.01]){rotate(a = [180,0,0]){cylinder(r = emtboltdia/2, h = wallthickness+5, $fn = 100);
cylinder(r1 = holediaupper/2, r2 = emtboltdia/2, h = holediaupperlegnth,$fn = 100);}}

translate([(distemts+Alsquareside+wallthickness*2)/2+(distemts/2),wallthicknesslegnth+legnth/2,-.01]){rotate(a = [0,0,0]){cylinder(r = emtboltdia/2, h = wallthickness+5, $fn = 100);
cylinder(r1 = holediaupper/2, r2 = emtboltdia/2, h = holediaupperlegnth,$fn = 100);}}

translate([(distemts+Alsquareside+wallthickness*2)/2-(distemts/2),wallthicknesslegnth+legnth/2,-.01]){rotate(a = [0,0,0]){cylinder(r = emtboltdia/2, h = wallthickness+5, $fn = 100);
cylinder(r1 = holediaupper/2, r2 = emtboltdia/2, h = holediaupperlegnth,$fn = 100);}}

}

module gimbalholder(){
difference(){
    union(){
        //base cube
        translate([]){cube([distemts+Alsquareside+wallthickness*2,legnth+wallthicknesslegnth,Alsquareside+wallthickness*2]);}
        //additional hub
        translate([(distemts+Alsquareside+wallthickness*2)/2,0,(Alsquareside+wallthickness*2)/2]){rotate(a = [270,0,0]){cylinder(r = hubdia/2, h = hubthickness,$fn = 100);}}
    }
    
    union(){
        //two Al squares
        translate([(distemts+Alsquareside+wallthickness*2)/2+(distemts/2)- Alsquareside/2,wallthicknesslegnth,wallthickness+Alsquareside]){rotate(a = [270,0,0]){cube([Alsquareside,Alsquareside,legnth+wallthicknesslegnth + 5]);}}

        translate([(distemts+Alsquareside+wallthickness*2)/2-(distemts/2)- Alsquareside/2,wallthicknesslegnth,wallthickness+Alsquareside]){rotate(a = [270,0,0]){cube([Alsquareside,Alsquareside,legnth+wallthicknesslegnth + 5]);}}
                
        //hub holes
        for(i = [0:numhubbolts])
        {
            translate([hubboltsplacementradius*cos((360/numhubbolts)*i) + (distemts+Alsquareside+wallthickness*2)/2,-1,hubboltsplacementradius*sin((360/numhubbolts)*i) + (Alsquareside+wallthickness*2)/2]){rotate(a = [270,0,0]){cylinder(r = hubboltsdia/2, h = wallthicknesslegnth + 5 + legnth, $fn = 100);}}
        }
        
        //if shafts extends past hub
        translate([(distemts+Alsquareside+wallthickness*2)/2,-2,(Alsquareside+wallthickness*2)/2]){rotate(a = [270,0,0]){cylinder(r = gearshaftdia/2, h = wallthicknesslegnth + 5 + legnth, $fn = 100);}}
        
        //holding bolt to emt (try countersunk)
        holdingscrews();
        
    }
}}

gimbalholder();
