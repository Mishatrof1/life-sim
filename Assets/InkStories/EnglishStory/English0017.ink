VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Male"
VAR GroupTitle = "School"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



I injured my arm at school. What do I do?
* [Apply to the nurse]
    -> res1
* [Never mind, it will be alright]
    -> res2
* [I'll take care of it when I get home]
    -> res3
* [Make a fuss about it to get the right to skip school]
    -> res4

=== res1 === 
The professional medical aid really helped me recover
~TextForLog = "I injured my arm and applied to the school nurse. The professional medical aid really helped me recover."
* [Ok]
-> END
=== res2 === 
The wound got infected, and I nearly died. Now, my arm is working badly
~TextForLog = "I injured my arm but decided not to do anything with it. The wound got infected, and I nearly died. Now, my arm is working badly."
* [Ok]
-> END
=== res3 === 
The wound took a long time to heal and left an ugly scar
~TextForLog = "I injured my arm and and treated the wound myself.  It took a long time to heal and left an ugly scar."
* [Ok]
-> END
=== res4 === 
They cracked my fraud and shamed me. I'm considering changing schools
~TextForLog = "I injured my arm and pretended to be seriously ill to be able to skip school.But they cracked my fraud and shamed me."
* [Ok]
-> END