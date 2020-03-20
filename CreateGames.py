import random

NUM_TEAMS = 6
NUM_GAMES = 30
MIN_SCORE = 80
MAX_SCORE = 120

for i in range(NUM_GAMES):
	ID = str(i + 1)
	
	HomeTeamID = str(random.randint(1, NUM_TEAMS))
	AwayTeamID = str(random.randint(1, NUM_TEAMS))
	
	if HomeTeamID == AwayTeamID:
		AwayTeamID = str((int(AwayTeamID) % NUM_TEAMS) + 1)
	
	HomeTeamPoints = str(random.randint(MIN_SCORE, MAX_SCORE))
	AwayTeamPoints = str(random.randint(MIN_SCORE, MAX_SCORE))
	
	if HomeTeamPoints == AwayTeamPoints:
		AwayTeamPoints = str(int(AwayTeamPoints) - 1)
	
	format_list = [ID, HomeTeamID, AwayTeamID, HomeTeamPoints, AwayTeamPoints]
	print("new Game() {{ ID = {}, HomeTeamID = {}, AwayTeamID = {}, HomeTeamPoints = {}, AwayTeamPoints = {} }},".format(*format_list))
