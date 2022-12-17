VAR StoryTittle = ""
VAR StoryQuestion = "But I'm a little worried about spending too much money. What should I do?"
VAR StoryCategory = "Love"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob"
VAR Character0MinAgeSc = 15
VAR Character0MaxAgeSc = 22
VAR NPC0RelationshipSc = "SignificantOther"
VAR NPC0MinAgeSc = 15
VAR NPC0MaxAgeSc = 22

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0PopularityCh = 0

I want to take %FullName:NPC:1% out for %Pron:1:2% birthday.
But I'm a little worried about spending too much money. What should I do?
* [Movie and dessert afterwards]
    -> res1
* [Chinese restaurant and horse-drawn carriage ride]
    -> res2
* [Take %FullName:NPC:1% to the fancy Italian restaurant.]
    -> res3
* [Take %FullName:NPC:1% to a spa day at a discount spa.]
    -> res4

=== res1 === 
Me and %FullName:NPC:1% go see a movie then have a delicious dessert and she is quite happy with the night.
~TextForLog = "This was one of my cheaper ideas so I am happy with that. Didn't have to break the bank. And it went well! %FullName:NPC:1% and I enjoyed the movie and had a delicious dessert, so all in all, I think it was a pretty good birthday for %Pron:1:2%. Can't complain about movies and dessert, right?"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-40%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
The Chinese restaurant and the carriage ride were moderately priced and we had a really good time with both!
~TextForLog = "This wasn't the cheapest option but it also wasn't the most expensive option. And it went well, %FullName:NPC:1% enjoyed dinner and really loved the horse drawn carriage. I'll admit, it did seem pretty romantic to me too. And we happened to see a lot of our friends while on the carriage and everyone now thinks I'm this real smooth operator."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-60%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
This place is pricey but %FullName:NPC:1% absolutely loves it and had been dying to go, so it was worth it.
~TextForLog = "Alright, this was an expensive meal for me but %FullName:NPC:1% was so happy that I took %Pron:1:2% there, it definitely scored me some major points. And the restaurant really was incredible. I just may have to tighten up the purse strings after that visit. Who knew food could even cost that much for just two people?!"
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0WealthCh = "%-90%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res4 === 
It's a discount spa for a reason, they're awful. They end up hurting us both during a couples massage.
~TextForLog = "%FullName:NPC:1% is so mad at me for choosing this cheap place. I thought it would still be alright! But the employees clearly didn't know what they were doing. They tried massaging us and hurt us both. Our backs are in such pain now, it's awful. What a terrible day... I'm so upset."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:1:-%"
~Character0WealthCh = "%-40%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
