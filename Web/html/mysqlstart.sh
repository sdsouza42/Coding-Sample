 sudo /etc/init.d/mysqld stop
 sudo /etc/init.d/mysqld restart
 sudo rm /var/lib/mysql/mysql.sock
 sudo ln -s /tmp/mysql.sock /var/lib/mysql/mysql.sock
 sudo /etc/init.d/mysqld restart
