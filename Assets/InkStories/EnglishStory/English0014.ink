VAR AgeMinCondition = 7
VAR AgeMaxCondition = 10
VAR SexCondition = "Female"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



I see some unknown man following me everywhere. My actions?
* [Run home and tell my parents about him]
    -> res1
* [Keep walking, I must be mistaken]
    -> res2
* [Come up to that guy and ask him what he wants]
    -> res3
* [Continue my way, but keep an eye on that guy]
    -> res4

=== res1 === 
My parents reported the man to the police; he turned out an old-time pedophile. I'm glad the cops have him now
~TextForLog = "I noticed an unknown man following me everywhere. I told my parents, and we went to the police station. The man turned out a pedophile; he was detained."
* [Ok]
-> END
=== res2 === 
He followed and attacked me. I started screaming and biting, and some guys came round and got him. He's at the police station now
~TextForLog = "I noticed an unknown man following me everywhere. I didn't want to pay attention, and he attacked me. I screamed for help, and some people came round and caught him. He's at the police station now."
* [Ok]
-> END
=== res3 === 
The man's was confused and hurried away. I don't know what he wanted
~TextForLog = "I noticed an unknown man following me everywhere. I asked him directly what he wanted, and he left. I never saw him again."
* [Ok]
-> END
=== res4 === 
The man attempted to attack me, but I ran away. Now, cops are looking for him
~TextForLog = "I noticed an unknown man following me everywhere. I kept an eye on him, and at his attempt to attack me I ran away."
* [Ok]
-> END