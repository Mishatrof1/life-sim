VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Female"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



We were out clubbing when one of my girlfriends got drunk and started acting ugly. How should I react?
* [Make a video of her with my mobile and post it on the Internet]
    -> res1
* [Call her a taxi to take her home]
    -> res2
* [I don't care, she's a big girl]
    -> res3
* [Use some harsh shaming]
    -> res4

=== res1 === 
She got crazy with shame and tried killing herself with sleeping pills. I wonder if this idiot has any brain at all...
~TextForLog = "We were out clubbing when one of my girlfriends got drunk and started acting ugly. I posted a video of her online. She got crazy with shame and tried killing herself with sleeping pills, but luckily failed. I wonder if this idiot has any brain at all..."
* [Ok]
-> END
=== res2 === 
She was so grateful to me in the morning, I felt a little confused
~TextForLog = "We were out clubbing when one of my girlfriends got drunk and started acting ugly. I called her a taxi to take her home. She was so grateful to me in the morning, I felt a little confused."
* [Ok]
-> END
=== res3 === 
Next morning, I learnt that she had been beaten up and got into a hospital. Well, I think she got what she was looking for
~TextForLog = "We were out clubbing when one of my girlfriends got drunk and started acting ugly. I stayed away from it. Next morning, I learnt that she had been beaten up and got into a hospital. Well, I think she got what she was looking for."
* [Ok]
-> END
=== res4 === 
Instead of a thank you, she initiated a fight. I gave her a couple of slaps
~TextForLog = "We were out clubbing when one of my girlfriends got drunk and started acting ugly. I harshly shamed her, and she started fighting me. I gave her a couple of slaps."
* [Ok]
-> END