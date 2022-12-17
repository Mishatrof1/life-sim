VAR AgeMinCondition = 7
VAR AgeMaxCondition = 10
VAR SexCondition = "Female"
VAR GroupTitle = "School"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



I was in the park when a man opened up his coat before me, and he was all naked under it! Then, he ran away. What should I do?
* [Tell my parents about that]
    -> res1
* [Run away and never tell anyone about it cuz it feels shameful]
    -> res2
* [Shout for help]
    -> res3
* [Laugh at the man and tease him. Then, tell this story to everybody]
    -> res4

=== res1 === 
My parents took me to the police station. They questionned me for a long time there, but they never caught anyone
~TextForLog = "I was in the park when a man opened up his coat before me, and he was all naked under it!  My parents called the police, but they never caught the man."
* [Ok]
-> END
=== res2 === 
No I'm scared of walking in that park and I'm having nightmares
~TextForLog = "I was in the park when a man opened up his coat before me, and he was all naked under it!  I ran away and never told anyone about it cuz it feels shameful. Now I'm afraid of going to that park and I'm having nightmares."
* [Ok]
-> END
=== res3 === 
Some grown-ups came up. They got that man and took him to the police station
~TextForLog = "I was in the park when a man opened up his coat before me, and he was all naked under it!  I shouted for help, the man got caught and was taken to the police."
* [Ok]
-> END
=== res4 === 
Nobody believed me, they say I made it up. Next time, I'll throw a rock at that man
~TextForLog = "I was in the park when a man opened up his coat before me, and he was all naked under it! I started mocking the man, and he ran away. Nobody believes me though. Next time, I'll throw a stone at the man."
* [Ok]
-> END