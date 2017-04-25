FROM mono:latest
ADD . /home/david/sieve
RUN nuget restore ValueUncertaintyGame.sln
RUN xbuild ValueUncertaintyGame.sln
CMD [ "mono", "/ValueUncertaintyGameRunner/bin/Debug/ValueUncertaintyGameRunner.exe" ]
