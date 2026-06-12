import os

runs = 100
ai = "ALL"
mypath = "./games/Valet"

for (dirpath, dirnames, filenames) in os.walk(mypath):
    for name in filenames:
        nump = int(name[-5])
        if ai == "NONE":
            acount = 0
        elif ai == "ONE":
            acount = 1
        else:
            acount = nump
        ais = "M" * acount + "R" * (nump - acount)
        exp = ("dotnet run --configuration Release Valet/" + name[:-5], name[-5], str(runs), ais)
        os.system(" ".join(exp))
#os.system("dotnet run --configuration Release Valet/Klaverjassen 4 100 MRRR")