#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <sys/un.h>
#include <sys/socket.h>

#define SOCKPATH "/tmp/teststrmsock"
#define BUFSZ 80

extern int ProcessBuffer(char[], int);

int RunServer(void)
{
	//Step 1
	int server = socket(AF_UNIX, SOCK_STREAM, 0);
	struct sockaddr_un local = {AF_UNIX, SOCKPATH};
	int status = bind(server, (struct sockaddr*) &local, sizeof(local));
	if(status == -1)
		return puts("ERROR: Bind failure");
	listen(server, 10);

	for(;;)
	{
		//Step 2
		int client = accept(server, NULL, NULL);

		//Step 3
		char buffer[BUFSZ];
		int n = recv(client, buffer, BUFSZ, 0);
		ProcessBuffer(buffer, n);
		send(client, buffer, n, 0);

		//Step 3
		close(client);
	}

}

int RunClient(const char* text)
{
	struct sockaddr_un remote = {AF_UNIX, SOCKPATH};
	int status, n = strlen(text);

	//Step 1
	int client = socket(AF_UNIX, SOCK_STREAM, 0);
	struct sockaddr_un local = {AF_UNIX};
	bind(client, (struct sockaddr*) &local, sizeof(local));
	status = connect(client, (struct sockaddr*) &remote, sizeof(remote));
	if(status == -1)
		return puts("ERROR: Connection failure");

	//Step 2
	n = send(client, text, n, 0);
	if(n > 0)
	{
		char buffer[BUFSZ] = "";
		n = recv(client, buffer, BUFSZ - 1, 0);
		if(n > 0)
			printf("Response: %s\n", buffer);
		else
			printf("ERROR: Communication failure");
	}
	else
		printf("ERROR: Communication failure");

	//Step 3
	close(client);
}

int main(int argc, char* argv[])
{
	if(argc == 1)
	{
		unlink(SOCKPATH);
		RunServer();
	}
	else
		RunClient(argv[1]);
}

