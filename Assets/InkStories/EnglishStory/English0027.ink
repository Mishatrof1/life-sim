VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Female"
VAR GroupTitle = "School"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



A young cute teacher is making moves on me. How do I react?
* [Report sexual harassment to the principal]
    -> res1
* [Why don't I have an affair with him?]
    -> res2
* [Turn him down straightaway]
    -> res3
* [Play with him a little, then dump him]
    -> res4

=== res1 === 
The teacher got fired, and I was transferred to another class. It had a negative effect on my studying results, but I did the right thing
~TextForLog = "A young cute teacher was making moves on me. I reported sexual harassment to the principal and the teacher was fired. I think he got off cheap."
* [Ok]
-> END
=== res2 === 
It went well until we got busted by his wife. So, we had to end this to avoid scandal
~TextForLog = "A young cute teacher was making moves on me. We started an affair and it went well until we got busted by his wife. We had to end this to avoid scandal."
* [Ok]
-> END
=== res3 === 
I ended it before it even started, but sometimes I picture what it would be like if I had chosen a different thing
~TextForLog = "A young cute teacher was making moves on me. I turned him down straightaway, but sometimes I picture what it would be like if I had chosen a different thing."
* [Ok]
-> END
=== res4 === 
He tried running his hands over me, but I played an ice maiden. Time to learn a little lesson!
~TextForLog = "A young cute teacher was making moves on me. He tried running his hands over me, but I played an ice maiden. Hope he learnt his lesson!"
* [Ok]
-> END