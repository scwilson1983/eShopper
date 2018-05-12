FROM microsoft/aspnetcore:2.0
 
RUN apt-get update && apt-get install -y --no-install-recommends apt-utils
RUN apt-get install -y nginx
 
WORKDIR /app
COPY bin/Debug/netcoreapp2.0/publish .

COPY ./startup.sh .
RUN chmod 755 /app/startup.sh
 
RUN rm /etc/nginx/nginx.conf
COPY nginx.conf nginx-selfsigned.crt nginx-selfsigned.key /etc/nginx/
 
ENV ASPNETCORE_URLS http://127.0.0.1:5000
CMD ["sh", "/app/startup.sh"]