VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Male"
VAR GroupTitle = "Work"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



Everyone in our office keeps trolling that new employee. How do I act?
* [Start trolling him, too]
    -> res1
* [Stick up for him]
    -> res2
* [Stay neutral]
    -> res3
* [Report the situation to our boss]
    -> res4

=== res1 === 
The new guy tried to put up with it for some time. Then, he told on us and our boss took harsh measures
~TextForLog = ""
* [Ok]
-> END
=== res2 === 
We are now both their target; and he wasn't grateful to me at all!
~TextForLog = ""
* [Ok]
-> END
=== res3 === 
The new guy told on us, and our boss took action against everyone except of me
~TextForLog = ""
* [Ok]
-> END
=== res4 === 
The stalkers got it; I've been an outsider with my colleagues, but in good standing with our boss
~TextForLog = ""
* [Ok]
-> END