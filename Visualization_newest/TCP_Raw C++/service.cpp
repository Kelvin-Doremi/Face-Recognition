#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <unistd.h>

#define MAXLINE 4096

int main()
{
    int listenfd,connfd;
    struct sockaddr_in servaddr;
    char buff[4096];
    int n;

    //创建一个TCP的socket
    if( (listenfd = socket(AF_INET,SOCK_STREAM,0)) == -1) {
        printf(" create socket error: %s (errno :%d)\n",strerror(errno),errno);
        return 0;
    }
	
    //先把地址清空，检测任意IP
    memset(&servaddr,0,sizeof(servaddr));
    servaddr.sin_family = AF_INET;
    servaddr.sin_addr.s_addr = htonl(INADDR_ANY);
    servaddr.sin_port = htons(6666);

	
    //地址绑定到listenfd
    if ( bind(listenfd, (struct sockaddr*)&servaddr, sizeof(servaddr)) == -1) {
        printf(" bind socket error: %s (errno :%d)\n",strerror(errno),errno);
        return 0;
    }

    //监听listenfd
    if( listen(listenfd,10) == -1) {
        printf(" listen socket error: %s (errno :%d)\n",strerror(errno),errno);
        return 0;
    }

    printf("====waiting for client's request=======\n");
    //accept 和recv,注意接收字符串添加结束符'\0'
    while(1)
    {

        if( (connfd = accept(listenfd, (struct sockaddr *)NULL, NULL))  == -1) {
            printf(" accpt socket error: %s (errno :%d)\n",strerror(errno),errno);
            return 0;
        }
        n = recv(connfd,buff,MAXLINE,0);
        buff[n] = '\0';
        printf("recv msg from client:%s\n",buff);
        close(connfd);
    }
    close(listenfd);
    return 0;
}
