export class DomainAuctionInfo {
    MaxBidAddress: string = "EQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAM9c";
    MaxBidAmount: number = 0;
    AuctionEndTime: Date = new Date();
}

export class DomainDnsEntries {
    Wallet: string | null = null;
    SiteADNL: string | null = null;
    SiteStorage: string | null = null;
    Storage: string | null = null;
    NextResolver: string | null = null;
}

export class DomainInfo {
    FullName: string = "foundation.ton";
    Address: string = "EQCD39VS5jcptHL8vMjEXrzGaRcCVYto7HUn4bpAOg8xqB2N";
    Deployed: boolean = true;
    Index: string = "nH1WzBFefPbCXhJr6nfLw8sV1VEG8uOXViWRBZlj+qM=";
    Collection: string = "EQC3dNlesgVD8YbAazcauIrXBPfiVhMMr5YYk2in0Mtsz0Bz";
    Domain: string = "foundation";
    Owner: string = "EQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAM9c";
    AuctionInfo: DomainAuctionInfo | null = null;
    LastFillUpTime: Date = new Date();
    DnsEntries: DomainDnsEntries = new DomainDnsEntries();
}
