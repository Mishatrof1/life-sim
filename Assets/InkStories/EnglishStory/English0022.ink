VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Male"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



The neighborhood guys are going to the abandoned house which everybody believes is haunted. What do I do?
* [Join them]
    -> res1
* [Refuse, as it's school night and I have to get up early]
    -> res2
* [Say no, but actually go there in secret and scare them to death]
    -> res3
* [Mock their idea and suggest burning down the haunted house instead]
    -> res4

=== res1 === 
It was really creepy! I got scared by somebody's shadow. We all ran away and swore not to tell anybody about it to avoid the mockery
~TextForLog = ""
* [Ok]
-> END
=== res2 === 
In the morning, I learned that those guys had disappeared. Everybody's searching for them, but vainly. This is just the worst nightmare ever!
~TextForLog = ""
* [Ok]
-> END
=== res3 === 
We weren't alone in the house! I screamed with fear, and the three of us ran away and swore to keep quiet about what we saw, to avoid the mockery
~TextForLog = ""
* [Ok]
-> END
=== res4 === 
We brought some petrol and set the house on fire. There was a wild wail, and then it was quiet. What it was, it remained a mystery, forever
~TextForLog = ""
* [Ok]
-> END