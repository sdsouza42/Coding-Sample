#!/usr/bin/python

import datetime
import cgi

now = datetime.datetime.now().strftime('%Y-%m-%d %H:%M:%S')
user = 'Visitor'

# http://localhost/cgi-bin/welcome.cgi?user=Jack
request = cgi.FieldStorage()

if request.has_key('user'):
	user = request['user'].value

print "Content-type:text/html\r\n\r\n"

print "<html>"
print "<head><title></title></head>"
print "<body>"
print "<h1>Welcome %s</h1>" % user
print "<b>Current time on server:</b>", now
print "</body>"
print "</html>"








