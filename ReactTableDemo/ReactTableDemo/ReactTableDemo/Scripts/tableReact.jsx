var EmployeeGridRow = React.createClass({
    render: function () {
        return (
            <tr>
                @* Sorry my mistake *@
                    <td>{this.props.item.FirstName}</td>
                <td>{this.props.item.LastName}</td>
                <td>{this.props.item.EmailID}</td>
                <td>{this.props.item.City}</td>
                <td>{this.props.item.Country}</td>
            </tr>
        );
    }
});

var EmployeeGridTable = React.createClass({
    getInitialState: function () {
        return {
            items: []
        }
    },
    componentDidMount: function () {
        $.get(this.props.dataUrl, function (data) {
            if (this.isMounted()) {
                this.setState({
                    items: data
                });
            }
        }.bind(this));
    },
    render: function () {
        var rows = [];
        this.state.items.forEach(function (item) {
            rows.push(<EmployeeGridRow key={item.EmployeeID} item={item} />);
        });
        return (
            <table className="table table-responsive">
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Email ID</th>
                        <th>City</th>
                        <th>Country</th>
                    </tr>
                </thead>
                <tbody>
                    {rows}
                </tbody>
            </table>
        );
    }
});
ReactDOM.render(
    <EmployeeGridTable dataUrl="/home/getEmployeeList" />,
    document.getElementById('griddata'));