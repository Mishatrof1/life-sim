VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Female"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



My ex who actually dumped me wants to get back together. What should I tell him?
* [Say yes cuz I still have feelings for him]
    -> res1
* [Blow him off, getting back together with your ex is a bad idea]
    -> res2
* [Give him a hope, and then dump him. I want him to suffer, just like I did!]
    -> res3
* [Take him back, but first play with him a little]
    -> res4

=== res1 === 
I'm such an idiot! All he wanted was sex, and once he got it, he left me again
~TextForLog = "My ex who actually dumped me wanted to get back together. I was an idiot to say yes cuz he only wanted sex, and once he got it, he left me again."
* [Ok]
-> END
=== res2 === 
He's suffering, yay! Me too, but it's all right, as long as he's having a hard time
~TextForLog = "My ex who actually dumped me wanted to get back together, but I blew him off. He's suffering, yay! Me too, but it's all right, as long as he's having a hard time."
* [Ok]
-> END
=== res3 === 
I'm enjoying his suffering! I'll tell all the girls to treat him the same way
~TextForLog = "My ex who actually dumped me wanted to get back together. This time, I dumped him to make him suffer. This is what he deserves!"
* [Ok]
-> END
=== res4 === 
Me acting hard to get made him gentle and caring. The main thing now is not to go to bed with him too soon
~TextForLog = "My ex who actually dumped me wanted to get back together. Me acting hard to get made him gentle and caring. The main thing now is not to go to bed with him too soon."
* [Ok]
-> END