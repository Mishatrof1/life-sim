VAR StoryTittle = ""
VAR StoryQuestion = "Which one should I go with?"
VAR StoryCategory = "Love"
VAR TextForLog = ""

VAR Character0OccupationSc = "FullTimeJob"
VAR Character0MinAgeSc = 25
VAR Character0MaxAgeSc = 55
VAR Character0GenderSc = "Male"
VAR Character0SexualPreferencesSc = "Straight"
VAR NPC0RelationshipSc = "Partner"
VAR NPC0GenderSc = "Female"
VAR NPC0MinAgeSc = 25
VAR NPC0MaxAgeSc = 55

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0IntelligenceCh = 0

I'm looking to buy a gift for %FullName:NPC:1% and have it narrowed down to three options.
Which one should I go with?
* [The watch]
    -> res1
* [The earrings]
    -> res2
* [The necklace]
    -> res3

=== res1 === 
%FullName:NPC:1% loves the watch... but it was the most expensive option.
~TextForLog = "I'm glad %FullName:NPC:1% loved the watch, I figured I couldn't go wrong when I saw the price tag. It was the most expensive option but it was worth it to make her this happy. And she is VERY happy."
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0WealthCh = "%-125%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res2 === 
These end up being the same earrings I got %FullName:NPC:1% and now she is mad.
~TextForLog = "%FullName:NPC:1% is mad, not only because she didn't get a new gift but also because I can't even remember what I already bought for her. She thinks I'm not even paying attention to what I buy for her. That's not true! I looked at these earrings and thought she would really like them! It's just that... I had that same thought once before... at least I didn't spend too much money..."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-65%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:1% really likes the necklace and is very happy.
~TextForLog = "Alright, %FullName:NPC:1% is very happy with the necklace. I'm so glad. It wasn't the cheapest of the three options but it also wasn't the most expensive. So, I am very happy to be able to give %FullName:NPC:1% a gift she really liked but also save a bit of money. Not bad at all! This may have been the smartest choice."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-90%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
