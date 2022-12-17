VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Male"
VAR GroupTitle = "Family"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



Dad got drunk at the bar and is yelling at Mom. My actions?
* [Stand up for Mom]
    -> res1
* [Hide away from this nightmare]
    -> res2
* [Throw a tantrum]
    -> res3
* [Storm out]
    -> res4

=== res1 === 
Dad hit me, but at least I protected Mom. I hate him!
~TextForLog = ""
* [Ok]
-> END
=== res2 === 
Dad slapped Mom. They will probably separate now
~TextForLog = ""
* [Ok]
-> END
=== res3 === 
Dad freaked out and slapped me. Mom tried to stick up for me, and he hit her, too. I hate him!
~TextForLog = ""
* [Ok]
-> END
=== res4 === 
My parents made up and went on search for me. I got back home and it all ended well
~TextForLog = ""
* [Ok]
-> END