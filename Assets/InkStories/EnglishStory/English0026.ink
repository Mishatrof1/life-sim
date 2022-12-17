VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Male"
VAR GroupTitle = "School"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



My classmate has "borrowed" his father's car and invites me to have a ride. How should I react?
* [Join him on the passenger seat]
    -> res1
* [Refuse cuz this is dangerous and illegal]
    -> res2
* [Accept the invitation and take the driver's seat]
    -> res3
* [Talk him out of it, and threaten to tell his father about it]
    -> res4

=== res1 === 
We got stopped by the first policeman we met and spent the rest of the day in a police station. Luckily, it wasn't me driving
~TextForLog = "My classmate \"borrowed\" his father's car and invited me to have a ride. We got stopped by the first policeman we met and spent the rest of the day in a police station. Luckily, it wasn't me driving."
* [Ok]
-> END
=== res2 === 
He said I was a coward. He went on a ride anyway and crashed his father's car. What an idiot!
~TextForLog = "My classmate \"borrowed\" his father's car and invited me to have a ride. I refused, and he said I was a coward. He went on a ride anyway and crashed his father's car. What an idiot!"
* [Ok]
-> END
=== res3 === 
It was the hell of a ride! My classmate nearly pissed his pants, but everything ended well
~TextForLog = "My classmate \"borrowed\" his father's car and invited me to have a ride. I took the driver's seat and gave us a great journey!"
* [Ok]
-> END
=== res4 === 
He put the car back into the garage. We're not in a movie car chase, after all
~TextForLog = "My classmate \"borrowed\" his father's car and invited me to have a ride. I threatened to tell his father about it, and he gave up his idea. We're not in a movie car chase, after all."
* [Ok]
-> END