VAR AgeMinCondition = 7
VAR AgeMaxCondition = 10
VAR SexCondition = "Male"
VAR GroupTitle = "School"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



Our school counselor asks me how a plane is different from a bird. What should I answer?
* [A bird is alive, and a plane isn't]
    -> res1
* [A bird flaps its wings, and a plane doesn't]
    -> res2
* [A bird eats the feed, and the plane consumes the fuel]
    -> res3
* [A bird has a beak and talons, and a plane doesn't]
    -> res4

=== res1 === 
They told me I passed the test and don't have to visit the counselor up to the end of the term
~TextForLog = "Our school counselor asked me how a plane was different from a bird. I said that a bird is alive, and a plane isn't. She seemed to like my answer."
* [Ok]
-> END
=== res2 === 
The school counselor was explaining something to Mom who looked quite shocked. What's wrong with me?
~TextForLog = "Our school counselor asked me how a plane was different from a bird. I said that birds flap their wings, and planes don't. Looks like there's something wrong with me."
* [Ok]
-> END
=== res3 === 
They told me I would have to visit the counselor every month now. Fine, I have some questions to her, too, and not about planes!
~TextForLog = "Our school counselor asked me how a plane was different from a bird. I said that birds eat the feed, and planes consume fuel. Now I have to visit the counselor every month!"
* [Ok]
-> END
=== res4 === 
The counselor said she would need to observe me for a while. I think I'm just going to hide from her
~TextForLog = "Our school counselor asked me how a plane was different from a bird. I said that a bird has a beak and talons, and a plane doesn't. Now, she wants to observe me for a while, but I'm going to hide from her."
* [Ok]
-> END