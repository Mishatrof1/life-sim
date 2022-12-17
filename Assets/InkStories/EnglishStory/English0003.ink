VAR AgeMinCondition = 5
VAR AgeMaxCondition = 7
VAR SexCondition = "Male"
VAR GroupTitle = "Family"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



Mom and Dad are fighting and yelling at each other
* [Throw a tantrum and blame it all on both of them]
    -> res1
* [Take Mom's side and blame it all on Dad]
    -> res2
* [Take Dad's side and accuse Mom of starting the fight]
    -> res3
* [Just ignore their fight]
    -> res4

=== res1 === 
My parents made up and took me to a counselor. Now I feel myself a psycho
~TextForLog = "Mom and Dad were fighting and yelling. I threw a tantrum, and they took me to a therapist. Now I feel myself a psycho."
* [Ok]
-> END
=== res2 === 
Dad has been acting distant to me. I've got to apologize to him
~TextForLog = "Mom and Dad were fighting and yelling. I took Mom's side, and now Dad has been acting cold to me."
* [Ok]
-> END
=== res3 === 
Mom asked me not to act like this and said that she and Dad both love me. I'm a little embarrassed
~TextForLog = "Mom and Dad were fighting and yelling. I took Dad's side. Mom asked me not to act like this and said that she and Dad both love me. I'm a little embarrassed."
* [Ok]
-> END
=== res4 === 
My parents have made up, but who knows for how long?
~TextForLog = "Mom and Dad were fighting and yelling. I didn't interfere. They made up, I just don't know for how long."
* [Ok]
-> END