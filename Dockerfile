FROM mono:latest
ADD . ./ValueUncertaintyGameRunner/bin/Debug
CMD [ "mono", "ValueUncertaintyGameRunner.exe" ]
