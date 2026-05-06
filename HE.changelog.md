# HallerErne.OpenProtocolInterpreter Changelog

All notable changes to the Haller + Erne fork of OpenProtocolInterpreter.

Forked from [Rickedb/OpenProtocolInterpreter](https://github.com/Rickedb/OpenProtocolInterpreter) v6.1.1.

---

## [6.1.1] — 2026-05-06

### Added

- **AutomaticManualMode**: Mid0404 — Select automatic/manual mode (Integrator → Controller)
- **Hvo** (Hand-guided Visual Output): Mid0510 (subscribe), Mid0512 (acknowledge), Mid0513 (unsubscribe), Mid0515 (set HVO signal, Rev1: 4 lamps, Rev2: light number + status)
- **SocketTray**: Mid0520 (subscribe), Mid0522 (acknowledge), Mid0523 (unsubscribe), Mid0524 (socket tray status, 8 socket fields)
- **RexrothJob**: Mid0554 (subscribe job result), Mid0555 (job result upload), Mid0556 (acknowledge), Mid0557 (unsubscribe), Mid0570 (activate job), Mid0571 (start job), Mid0573 (select job number), Mid0574 (job manipulate)
- **Battery**: Mid0800 (request), Mid0801 (response: capacity + state), Mid0802 (subscribe with change level), Mid0803 (upload), Mid0804 (unsubscribe)
- **Wifi**: Mid0805 (request), Mid0806 (response: reception quality), Mid0807 (subscribe with change level), Mid0808 (upload), Mid0809 (unsubscribe)

### Changed

- Package renamed to `HallerErne.OpenProtocolInterpreter`
- Author/Company set to Haller + Erne GmbH
- `MidInterpreterMessagesExtensions`: added `UseBatteryMessages`, `UseHvoMessages`, `UseRexrothJobMessages`, `UseSocketTrayMessages`, `UseWifiMessages` with XML documentation
- `UseAllMessages()` now includes all five new categories

### Notes

- MID 500–504 (Rexroth I/O signals) deferred — conflicts with standard Motor Tuning MIDs at those numbers
- Field layouts sourced from Nexo V1400 Open Protocol specification and heOPTester reference implementation
