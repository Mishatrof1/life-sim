VAR AgeMinCondition = 7
VAR AgeMaxCondition = 10
VAR SexCondition = "Male"
VAR GroupTitle = "Family"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



I was playing at the backyard when I accidently broke Mom's favorite garden gnome. What do I do?
* [Lie to Mom that I have no idea about who did it]
    -> res1
* [Make up a story about the neighbors' dog that ran up to our backyard and broke it]
    -> res2
* [Run away from home]
    -> res3
* [Admit it was me and say I'm sorry]
    -> res4

=== res1 === 
Unfortunately, our neighbor saw me, she told Mom everything. I think Mom hates me now
~TextForLog = "I was playing at the backyard when I accidently broke Mom's favorite garden gnome. I tried saying it wasn't me, but our neighbor had seen me and sold me out."
* [Ok]
-> END
=== res2 === 
It turned out our neighbors were away in the country all day. Now, Mom knows I lied, so I think I'm going to get it! 
~TextForLog = "I was playing at the backyard when I accidently broke Mom's favorite garden gnome. I lied that it was the neighbors' dog, but my lying was disclosed cuz the neighbors and their dog had been away in the countryside all day."
* [Ok]
-> END
=== res3 === 
I wandered around all day, and in the evening, the police got me. The worst day ever!
~TextForLog = "I was playing at the backyard when I accidently broke Mom's favorite garden gnome. After that, I ran away from home, but the police caught me and returned home."
* [Ok]
-> END
=== res4 === 
Mom gave me a hard time for the broken gnome, but finally she forgave me and game me a kiss. Happy end!
~TextForLog = "I was playing at the backyard when I accidently broke Mom's favorite garden gnome. I confessed what I did, and Mom gave me a hard time but finally forgave me."
* [Ok]
-> END