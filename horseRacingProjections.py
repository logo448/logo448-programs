class payout(object):
    def __init__(self, bankroll, time, correct, odds, bet_percent):
        self.bankroll = float(bankroll)
        self.time = time
        self.correct = float(correct)
        self.odds = float(odds)
        self.bet_percent = float(bet_percent)
    def get_results(self):
        for i in range(1, self.time + 1):
            bet = self.bankroll * self.bet_percent
            print "You will bet %f dollars" % bet
            money = ((self.correct * self.odds) + (self.correct * -1)) * bet 
            print "You will make %f dollars" % money
            self.bankroll += money - bet
            print "After %d days, your bankroll is %f" % (i, self.bankroll)
            print ""
