VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Male"
VAR GroupTitle = "Family"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



It's Dad's birthday soon, but I don't have enough money to buy him a present. What should I do?
* [Buy some flowers and just be around Dad all day, taking good care of him]
    -> res1
* [Go and bet my last money in a casino]
    -> res2
* [Craft a present myself]
    -> res3
* [Give him some cheap gift. After all, it's Dad's fault I'm broke]
    -> res4

=== res1 === 
It's been long since we had such great quality time together! It was a wonderful day
~TextForLog = "It was my Dad's birthday, and I didn't have enough money to buy him a good present. So, I bought him flowers and spent the whole day around him. We had some good quality time together!"
* [Ok]
-> END
=== res2 === 
I won! Not much, but enough for a nice present. Dad said I I've become a grown up man. I think so, too!
~TextForLog = "It was my Dad's birthday, and I didn't have enough money to buy him a good present. So, I bet my last money in a casino and won enough for a nice gift. Dad said I'm all grown up now. I think so, too!"
* [Ok]
-> END
=== res3 === 
Dad patted me on the shoulder, and I think there were tears in his eyes
~TextForLog = "It was my Dad's birthday, and I didn't have enough money to buy him a good present. I crafted him a gift myself, and Dad was really moved."
* [Ok]
-> END
=== res4 === 
Dad warmly thanked me, and we had a good talk. It was a nice birthday!
~TextForLog = "It was my Dad's birthday, and I didn't have enough money to buy him a good present. I gave him something cheap, but he was happy anyways."
* [Ok]
-> END