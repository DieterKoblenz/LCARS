powercfg /SETACTIVE "Minimal Power Management"
powercfg /CHANGE "Minimal Power Management" /standby-timeout-ac 10
powercfg /CHANGE "Minimal Power Management" /disk-timeout-ac 8
powercfg /CHANGE "Minimal Power Management" /monitor-timeout-ac 5
powercfg /CHANGE "Minimal Power Management" /hibernate-timeout-ac 0
powercfg /CHANGE "Minimal Power Management" /processor-throttle-ac ADAPTIVE
