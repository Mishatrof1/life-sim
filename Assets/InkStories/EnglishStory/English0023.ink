VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Male"
VAR GroupTitle = "School"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



We're having a difficult test at school tomorrow. What should I do?
* [I have plenty of time, I'll study hard and get prepared for the test]
    -> res1
* [Bring some pepper to class and go "epidemic"]
    -> res2
* [Hack the school computer at night to get the test key]
    -> res3
* [Try my luck and not study at all]
    -> res4

=== res1 === 
I got an "A" for the test. Right decisions always grant success!
~TextForLog = ""
* [Ok]
-> END
=== res2 === 
Everybody started sneezing! The teacher freaked out at first, but then she smelled the pepper. I'm dead!
~TextForLog = ""
* [Ok]
-> END
=== res3 === 
I was nearly there when I got busted by the school guard. I managed to run away, but failed the test the next day
~TextForLog = ""
* [Ok]
-> END
=== res4 === 
I was lucky and got a "C"
~TextForLog = ""
* [Ok]
-> END