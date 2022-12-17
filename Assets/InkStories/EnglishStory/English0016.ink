VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Male"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



Some good mister told me he had a spare scooter back in his garage and offered me to have it. What should I do?
* [Follow the man to his garage]
    -> res1
* [I don't want to risk; say "Thanks, but no"]
    -> res2
* [Say no, but stay there and watch him to check if he coud be a maniac]
    -> res3
* [Memorize the man's looks and report him to the police]
    -> res4

=== res1 === 
I got a cool scooter! Not a brand new one, but still
~TextForLog = "Some good mister gave me a cool scooter!"
* [Ok]
-> END
=== res2 === 
The boy next door was boasting that some nice man gave him a scooter! I feel myself a stupid coward
~TextForLog = "Some good mister offered me his spare scooter, but I was scared to go with him. So, the scooter went to the boy next door."
* [Ok]
-> END
=== res3 === 
The man noticed me spying on him and told me off. Then, he gave the scooter to the boy next door, who is happy now, unlike me
~TextForLog = "Some good mister offered me his spare scooter. I thought he was a maniac and decided to watch him. He noticed me spying on him and told me off. The scooter went to the boy next door."
* [Ok]
-> END
=== res4 === 
False alarm. The police said I did well, but the scooter went to the boy next door. That's not too good
~TextForLog = "Some good mister offered me his spare scooter. I thought he was a maniac and reported him to the police. It was a false alarm, and the scooter went to the boy next door."
* [Ok]
-> END