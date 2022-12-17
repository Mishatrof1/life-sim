VAR AgeMinCondition = 5
VAR AgeMaxCondition = 7
VAR SexCondition = "Male"
VAR GroupTitle = "Family"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



My parents are in their bedroom, with the doors closed. I can hear some moaning coming from out there. What do I do?
* [Try knocking on the door and shouting]
    -> res1
* [Just ignore it]
    -> res2
* [Take advantage of their absence and watch an adult TV channel]
    -> res3
* [Peep through the keyhole]
    -> res4

=== res1 === 
I'm banned to watch cartoons for a week
~TextForLog = "My parents locked themselves in their bedroom doing some strange stuff. I knocked on the door and got banned from watching cartoons for a week."
* [Ok]
-> END
=== res2 === 
For being good, they bought me that toy I really wanted to have
~TextForLog = "My parents locked themselves in their bedroom doing some strange stuff. I didn't interfere and was given a toy for this."
* [Ok]
-> END
=== res3 === 
My parents gave me a really hard time I just don't know why
~TextForLog = "I didn't interfere and got a new toy for this. I took advantage of my parents' absence to watch an adult TV channel. They punished me then."
* [Ok]
-> END
=== res4 === 
I couldn't see anything. Whatever, next time I will figure it out
~TextForLog = "I was peeping through the keyhole but couldn't see anything."
* [Ok]
-> END