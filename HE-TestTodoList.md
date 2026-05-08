# HE Test Checklist — Rexroth/NEXO MIDs

Manual testing checklist for all newly implemented vendor-specific MIDs.  
Mark each MID as tested against a real Rexroth/NEXO controller.

## AutomaticManualMode

| MID | Description | Direction | Tested | Notes |
|-----|-------------|-----------|--------|-------|
| 0404 | Select automatic/manual mode | Int → Ctl | ☐ | |

## HVO (Hand-guided Visual Output)

| MID | Description | Direction | Tested | Notes |
|-----|-------------|-----------|--------|-------|
| 0510 | Subscribe HVO signals | Int → Ctl | ☐ | |
| 0512 | Acknowledge HVO upload | Int → Ctl | ☐ | |
| 0513 | Unsubscribe HVO signals | Int → Ctl | ☐ | |
| 0515 | Set HVO signal (Rev1: 4 lamps) | Int → Ctl | ☐ | |
| 0515 | Set HVO signal (Rev2: light#/status) | Int → Ctl | ☐ | |

## SocketTray

| MID | Description | Direction | Tested | Notes |
|-----|-------------|-----------|--------|-------|
| 0520 | Subscribe socket tray | Int → Ctl | ☐ | |
| 0522 | Acknowledge socket tray upload | Int → Ctl | ☐ | |
| 0523 | Unsubscribe socket tray | Int → Ctl | ☐ | |
| 0524 | Socket tray status (8 sockets) | Ctl → Int | ☐ | |

## RexrothJob

| MID | Description | Direction | Tested | Notes |
|-----|-------------|-----------|--------|-------|
| 0554 | Subscribe job result | Int → Ctl | ☐ | |
| 0555 | Job result upload | Ctl → Int | ☐ | |
| 0556 | Acknowledge job result | Int → Ctl | ☐ | |
| 0557 | Unsubscribe job result | Int → Ctl | ☐ | |
| 0570 | Activate job | Int → Ctl | ☐ | |
| 0571 | Start job | Int → Ctl | ☐ | |
| 0573 | Select job number | Int → Ctl | ☐ | |
| 0574 | Job manipulate | Int → Ctl | ☐ | |

## Battery

| MID | Description | Direction | Tested | Notes |
|-----|-------------|-----------|--------|-------|
| 0800 | Request battery status | Int → Ctl | ☐ | |
| 0801 | Battery status reply | Ctl → Int | ☐ | |
| 0802 | Subscribe battery (change level) | Int → Ctl | ☐ | |
| 0803 | Battery status upload | Ctl → Int | ☐ | |
| 0804 | Unsubscribe battery | Int → Ctl | ☐ | |

## Wifi

| MID | Description | Direction | Tested | Notes |
|-----|-------------|-----------|--------|-------|
| 0805 | Request WiFi quality | Int → Ctl | ☐ | |
| 0806 | WiFi quality reply | Ctl → Int | ☐ | |
| 0807 | Subscribe WiFi (change level) | Int → Ctl | ☐ | |
| 0808 | WiFi quality upload | Ctl → Int | ☐ | |
| 0809 | Unsubscribe WiFi | Int → Ctl | ☐ | |

---

## Deferred (Not Implemented)

| MID | Description | Reason |
|-----|-------------|--------|
| 0500–0504 | Rexroth I/O signals | Conflicts with standard Motor Tuning MIDs |
| 0511 | HVO state change upload | No field layout available |

---

**Legend:**  
- Int → Ctl = Integrator sends to Controller  
- Ctl → Int = Controller sends to Integrator  
- ☐ = Not tested | ☑ = Tested OK | ☒ = Test failed
