import { DashboardTile } from "../dashboard-tiles/dashboard-tile.model";

export type Dashboard = {
    id: any;
    name: string;
    dashboardTiles: Array<DashboardTile>;
};
