VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Male"
VAR GroupTitle = "Family"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



Mom is always trying to control me. What should I do?
* [I don't mind it, she's my mother]
    -> res1
* [Leave home and stay at my friends']
    -> res2
* [End all the contacts with her]
    -> res3
* [Talk to her about how unacceptable it is]
    -> res4

=== res1 === 
I may not have that much freedom, but I also don't have to care about things, either. Lol!
~TextForLog = ""
* [Ok]
-> END
=== res2 === 
Mom went to the police and they found me and took me back. Mom and I have been enemies ever since
~TextForLog = ""
* [Ok]
-> END
=== res3 === 
Mom couldn't bear me ignoring her and begged me to make up. Fine, but she owes me!
~TextForLog = ""
* [Ok]
-> END
=== res4 === 
Mom promised to change, but she didn't. We keep fighting all the time
~TextForLog = ""
* [Ok]
-> END