VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "FullTimeJob"
VAR NPC0RelationshipSc = "Partner"
VAR NPC0GenderSc = "Male"

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HealthCh = 0

My husband is sick and asks me to get his oil changed for his car at the dealership.
What do I do?
* [Bring it to the dealership even though it’s expensive.]
    -> res1
* [Bring it to the place around the corner that’s cheaper]
    -> res2
* [Bring it somewhere else to get the oil changed and get it washed]
    -> res3
* [Bring it to the dealership where I got my car and get a discount]
    -> res4

=== res1 === 
It costs a lot but they do a good job and my husband appreciates it and even orders delivery from my favorite restaurant.
~TextForLog = "I brought my husband’s car to his dealership and they did a great job. It cost a lot of money but it was worth it, my husband was happy and even ordered us food from my favorite restaurant! Pretty good day overall!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-250%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
My husband gets annoyed that I went to the cheap place because they don’t do a good job. But I saved some money.
~TextForLog = "I thought it would be a good idea to just save some money at the cheap place but my husband was really annoyed with me and then we got into a fight. Maybe I should’ve just spent the money."
~Character0WealthCh = "%-100%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
My husband is so happy with the gesture of getting his car washed as well, unfortunately, I catch a cold from someone at that place.
~TextForLog = "I think it was a good call to bring his car in somewhere to also get it washed and he definitely was really happy with the gesture. However, I got sick from someone at that place and now both my husband and I are sick!"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-200%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
They scratch my husband’s car and he gets mad at me for not just bringing it where he asked me to but they did gift me a bottle of wine at the dealership.
~TextForLog = "I’m kind of glad I went to my dealership because not only did I get a discount but they had a deal going on where I got a free bottle of wine! Although, they scratched my husband’s car and now he’s so mad at me... maybe wine will fix it?"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-150%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
