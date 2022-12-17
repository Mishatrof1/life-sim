VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Female"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



One of my girlfriends suggests going to a secret party where we could potentially have sex. What should I do?
* [Say no and and let her go alone]
    -> res1
* [Go to the party without telling my parents]
    -> res2
* [Try to talk her out of it cuz it can be dangerous]
    -> res3
* [Go to the party, but let my parents know where I am]
    -> res4

=== res1 === 
My friend went to the party alone. They got her drunk and brutally raped her. She's in the hospital now
~TextForLog = "One of my girlfriends suggests going to a secret party where we could potentially have sex. I refused, and she went alone. They got her drunk and brutally raped her. She's in the hospital now."
* [Ok]
-> END
=== res2 === 
We raved like crazy. I don't think I'll be really into group sex, though
~TextForLog = "One of my girlfriends suggests going to a secret party where we could potentially have sex. I went there, without telling my parents, and we raved like crazy. I don't think I'll be really into group sex, though."
* [Ok]
-> END
=== res3 === 
We argued and fell out since then. And, she didn't go there either cuz she said I ruined it for her
~TextForLog = "One of my girlfriends suggests going to a secret party where we could potentially have sex. I refused and didn't let her go, either, and we stopped being friends since then."
* [Ok]
-> END
=== res4 === 
In the middle of the party, my father suddenly came up and spoiled it all for everyone. I hate him! I hate myself! I hate them all!
~TextForLog = "One of my girlfriends suggests going to a secret party where we could potentially have sex. I went there but let my parents know where it was. In the middle of the party, my father suddenly came up and spoiled it all. I hate him! I hate myself! I hate them all!"
* [Ok]
-> END