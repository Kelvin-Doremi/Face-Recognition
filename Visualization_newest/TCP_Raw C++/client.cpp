#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <unistd.h>

#define MAXLINE 4096

int main(int argc, char**argv)
{
    int sockfd,n;
    char recvline[4096],sendline[4096];
    struct sockaddr_in servaddr;

    if(argc !=2)
    {
        printf("usage: ./client <ipaddress>\n");
        return 0;
    }
    //创建socket
    if( (sockfd = socket(AF_INET,SOCK_STREAM,0)) == -1) {
        printf(" create socket error: %s (errno :%d)\n",strerror(errno),errno);
        return 0;
    }
    
    memset(&servaddr,0,sizeof(servaddr));
    servaddr.sin_family = AF_INET;
    servaddr.sin_port = htons(6666);
    //IP地址从“点分十进制”转换到“二进制整肃”
    if( inet_pton(AF_INET,argv[1], &servaddr.sin_addr) <=0 ) {
        printf("inet_pton error for %s\n",argv[1]);
        return 0;
    }
    //连接
    if( connect(sockfd,(struct sockaddr*)&servaddr,sizeof(servaddr)) <0) {
        printf(" connect socket error: %s(errno :%d)\n",strerror(errno),errno);
        return 0;
    }

    printf("send msg to server:\n");
    fgets(sendline,4096,stdin);
    //send发送
    if ( send(sockfd,sendline,strlen(sendline),0) <0) {
        printf("send msg error: %s(errno :%d)\n",strerror(errno),errno);
        return 0;
    }

    close(sockfd);
    return 0;
}
