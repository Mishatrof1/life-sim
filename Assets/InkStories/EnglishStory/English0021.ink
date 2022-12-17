VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Male"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



Me and another boy climbed on the roof trying to prove we are tough. He started walking right on the roof's edge. My actions?
* [Pull him from the edge]
    -> res1
* [Perform an even more dangerous trick]
    -> res2
* [Try to persuade him to be careful]
    -> res3
* [Say that anyone could do this and laugh at him]
    -> res4

=== res1 === 
He pushed me away and fell down. Now he's in the hospital with a broken leg. A dumbass always gets it
~TextForLog = ""
* [Ok]
-> END
=== res2 === 
I fell off the roof and broke my leg. I'm at hospital now. How could I be so stupid?
~TextForLog = ""
* [Ok]
-> END
=== res3 === 
He stepped back from the roof edge and called me a coward. I don't care, as long as everyone's safe and sound
~TextForLog = ""
* [Ok]
-> END
=== res4 === 
He attacked me, and we started fighting. We're looking super cool now, all bruised
~TextForLog = ""
* [Ok]
-> END