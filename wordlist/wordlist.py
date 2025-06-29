import requests

def filterlist(unfiltered, minlength):
    filtered = []
    for word in unfiltered:
        if len(word) <= minlength:
            continue
        filtered.append(word)
    return filtered

minlength = 3 #Words 3 letters or shorter are not allowed in NYT games

listurl = "https://raw.githubusercontent.com/dwyl/english-words/refs/heads/master/words_alpha.txt" #wordlist source
response = requests.get(listurl)

if response.status_code == 200: #if the get request goes through unimpeded
    unfiltered = response.text.splitlines()
    filtered = filterlist(unfiltered, minlength)
    with open("C:/Users/zerte/OneDrive/Documents/GitHub/LetterBoxed-Solver/wordlist/wordlist.txt", "w") as newfile:
        for word in filtered:
            newfile.write(word + "\n")
else:
    print("Failed to download wordlist: HTTP {response.status_code}") #Returns error code allowing diagnosis


