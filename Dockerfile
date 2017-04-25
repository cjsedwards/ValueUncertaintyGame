FROM mono:latest
ADD . .
CMD [ "mono", "ValueUncertaintyGameRunner.exe" ]
