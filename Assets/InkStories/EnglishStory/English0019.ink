VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Female"
VAR GroupTitle = "School"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



The boys were watching over the girls in the school locker room. They all ran away, except for one. What should we do to him?
* [Beat him on the face with a shoe]
    -> res1
* [Report him to the teacher]
    -> res2
* [Let him go]
    -> res3
* [Strip for him a little, just for teasing]
    -> res4

=== res1 === 
He's got a broken nose, and I was taken to the police. I really shouldn't have lost my temper
~TextForLog = "The boys were watching over the girls in the school locker room. They all ran away, except for one. I beat him on the face with a shoe, broke his nose and had big troubles afterwards."
* [Ok]
-> END
=== res2 === 
They said I did the right thing, and that guy got some trouble. Well, I think he deserves it
~TextForLog = "The boys were watching over the girls in the school locker room. They all ran away, except for one. I told the teacher on him, and he had big problems. I hope it serves him right."
* [Ok]
-> END
=== res3 === 
He keeps staring at me, I think he likes me
~TextForLog = "The boys were watching over the girls in the school locker room. They all ran away, except for one. I let him go, and now he keeps staring at me. I think he likes me."
* [Ok]
-> END
=== res4 === 
The dude got so excited he almost lost his mind
~TextForLog = "The boys were watching over the girls in the school locker room. They all ran away, except for one. I stripped for him a little, and he got so excited he nearly lost his mind."
* [Ok]
-> END