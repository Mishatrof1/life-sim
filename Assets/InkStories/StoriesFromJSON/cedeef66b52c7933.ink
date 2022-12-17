VAR StoryTittle = ""
VAR StoryQuestion = "What should we do today?"
VAR StoryCategory = "Love"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 25
VAR Character0MaxAgeSc = 50
VAR Character0GenderSc = "Male"
VAR NPC0RelationshipSc = "Partner"
VAR NPC0GenderSc = "Female"
VAR NPC0MinAgeSc = 25
VAR NPC0MaxAgeSc = 50

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR NPC0HappinessCh = 0
VAR Character0StrengthCh = 0
VAR Character0EnduranceCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0WealthCh = 0

Me and %FullName:NPC:1% are trying out a new country club to see if we want to join.
What should we do today?
* [Play golf together]
    -> res1
* [Play tennis together]
    -> res2
* [Have lunch together]
    -> res3

=== res1 === 
We go out and golf nine holes and really enjoy ourselves, plus the walking from hole to hole gets us a bit of some exercise.
~TextForLog = "We both really enjoyed the golf course and it's really making us consider joining the country club. It was a lot of fun and getting all that fresh air and doing all that walking was pretty good for us too. Much better than just sitting inside all day long."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
We have a great time playing tennis until %FullName:NPC:1% twists her ankle and I have to pick her up and carry her back to the car.
~TextForLog = "I carry %FullName:NPC:1% all the way back to the car because she can't walk and then take her to the hospital. Luckily, the doctor says it isn't too bad. But %FullName:NPC:1% is so thankful to me for doing what I did. Of course, I wasn't going to leave her there! But the experience does actually make us even closer to one another interestingly enough."
~Character0HealthCh = "%ValueRef:0:+%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res3 === 
The lunch was delicious but very pricey. We have a great time together and share some laughs, but maybe if we join this club we will just partake in other activities.
~TextForLog = "We do love this country club but the lunch was so overpriced, even though it was delicious. We enjoyed it and I suppose it's nice to do lunch there every once in awhile. But we will be joining the club for golf or tennis or something... not these lunches. But it was still a wonderful afternoon. Just that my wallet is much lighter now."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-85%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
