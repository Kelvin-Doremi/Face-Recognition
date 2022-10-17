#include <stdio.h>
#include <iostream>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <unistd.h>
#include "my_tcp.h"

static int listenfd=-1;
int net_fd=-1;

unsigned char* g_net_buf[NET_IMG_MAX_BUF_NUMS]={NULL,};
cv::Mat* g_img;

int g_net_current_pos =-1;

/*
*@function create_accept_tcp
*@return : int
	0: error when create or bind or listen or accept
	>0: return socket client connected, and server accept return fd; 
*/
int create_accept_tcp()
{
	int connfd;

	struct sockaddr_in servaddr;
	int n = 0;
	int m;

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

	printf("!!! wait tcp client conneting........\n");
	//accept 和recv,注意接收字符串添加结束符'\0'
	if( (connfd = accept(listenfd, (struct sockaddr *)NULL, NULL))  == -1) {
		printf(" accpt socket error: %s (errno :%d)\n",strerror(errno),errno);
		return 0;
	}

	printf("accept ok, and return socket fd: %d\n", connfd);
	return connfd;
}



int create_net_bufs()
{
    for(int i=0; i< NET_IMG_MAX_BUF_NUMS; i++)
    {
    	g_net_buf[i] = (unsigned char*) malloc(sizeof(unsigned char)* NET_IMG_MAX_SZ);
        g_img = (cv::Mat*) malloc(sizeof(unsigned char) * 9216000);

    	if(g_net_buf[i]== NULL)
    	{
          printf("g_net_buf[i] malloc return NULL....\n");
          return -1;
    	}
        memset(g_net_buf[i],0 ,NET_IMG_MAX_SZ);
    }

    return 0;
}

int rcvd_from_tcp(int sockfd, unsigned char *data, int length)
{
	if (data == NULL)
		return 0;
	int one_recv, sum_recv = 0;
	while (sum_recv < length) {
		one_recv = recv(sockfd, data + sum_recv, length - sum_recv, 0);
		if (one_recv == 0)
			return 0;
		sum_recv += one_recv;
	}
	return sum_recv;
} 

int send_from_tcp(int sockfd, unsigned char *data, int length)
{
    int ret;
	if (data == NULL || length <0)
		return 0;
    ret = send(sockfd, data, length, 0); 
	return ret;
}


int close_my_tcp()
{
    for(int i=0; i< NET_IMG_MAX_BUF_NUMS; i++)
    {
    	if(g_net_buf[i]!= NULL)
    	{
          free(g_net_buf[i]);
          g_net_buf[i]= NULL;
    	}
    }
    free(g_img);
    if(net_fd>0)
	    close(net_fd);
    if(listenfd>0)
	    close(listenfd);
    printf("%s\n", __func__);
    return 0;
}

